import NextAuth, { NextAuthOptions, User } from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";
import { JWT } from "next-auth/jwt";
import axios, { AxiosError } from "axios";

interface LoginResponse {
  isAuthSuccessful: boolean;
  errorMessage: string | null;
}

interface BackendUser {
  id: number;
  email: string;
  userName: string;
  roles: string[];
  status: string;
}

interface ExtendedUser extends User {
  userName: string;
  roles: string[];
  status: string;
}

interface ExtendedToken extends JWT {
  id: number;
  email: string;
  userName: string;
  roles: string[];
  status: string;
  isValid?: boolean;
}

const NEXT_PUBLIC_BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;

export const authOptions: NextAuthOptions = {
  providers: [
    CredentialsProvider({
      name: "Credentials",
      credentials: {
        email: { label: "Email", type: "text" },
        password: { label: "Password", type: "password" },
      },
      async authorize(credentials) {
        if (!credentials?.email || !credentials?.password) {
          throw new Error("Missing credentials");
        }

        try {
          const loginResponse = await axios.post<LoginResponse>(
            `${NEXT_PUBLIC_BASE_URL}/auth/login`,
            {
              email: credentials.email,
              password: credentials.password,
            },
            {
              headers: { "Content-Type": "application/json" },
              withCredentials: true,
            }
          );

          if (!loginResponse.data.isAuthSuccessful) {
            throw new Error(loginResponse.data.errorMessage || "Login failed");
          }

          const userResponse = await axios.get<BackendUser>(
            `${NEXT_PUBLIC_BASE_URL}/auth/me`,
            {
              headers: { "Content-Type": "application/json" },
              withCredentials: true,
            }
          );

          const userData = userResponse.data;

          if (!userData.id) {
            throw new Error("Failed to fetch user data");
          }

          return {
            id: userData.id.toString(),
            email: userData.email,
            userName: userData.userName,
            roles: userData.roles,
            status: userData.status,
          } as ExtendedUser;
        } catch (error) {
          console.error("Authorize error:", error);
          if (error instanceof AxiosError && error.response) {
            throw new Error(
              error.response.data.errorMessage || "Authentication failed"
            );
          }
          throw new Error("An unexpected error occurred");
        }
      },
    }),
  ],
  session: {
    strategy: "jwt",
    maxAge: 600,
  },
  jwt: {
    secret: process.env.NEXTAUTH_SECRET,
  },
  callbacks: {
    async jwt({ token, user }) {
      if (user) {
        const extendedUser = user as ExtendedUser;
        token.id = parseInt(extendedUser.id);
        token.email = extendedUser.email;
        token.userName = extendedUser.userName;
        token.roles = extendedUser.roles;
        token.status = extendedUser.status;
      }

      const isValid = await checkTokenWithBackend();
      if (!isValid) {
        return { ...token, isValid: false };
      }

      return token as ExtendedToken;
    },
    async session({ session, token }) {
      if ((token as ExtendedToken).isValid === false) {
        return {
          ...session,
          user: undefined,
          expires: new Date(0).toISOString(),
        };
      }

      return {
        ...session,
        user: {
          ...session.user,
          id: (token as ExtendedToken).id,
          email: (token as ExtendedToken).email,
          userName: (token as ExtendedToken).userName,
          roles: (token as ExtendedToken).roles,
          status: (token as ExtendedToken).status,
        },
      };
    },
  },
  cookies: {
    sessionToken: {
      name: `next-auth.session-token`,
      options: {
        httpOnly: true,
        secure: process.env.NODE_ENV === "production",
        sameSite: "lax",
        path: "/",
      },
    },
  },
};

const checkTokenWithBackend = async (): Promise<boolean> => {
  try {
    const response = await axios.get(`${NEXT_PUBLIC_BASE_URL}/auth/me`, {
      withCredentials: true,
    });
    return response.status === 200;
  } catch (error) {
    console.error("Token verification error:", error);
    return false;
  }
};

export default NextAuth(authOptions);
