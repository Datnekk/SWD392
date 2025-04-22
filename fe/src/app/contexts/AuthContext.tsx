import {
  createContext,
  useContext,
  useEffect,
  useState,
  ReactNode,
  useCallback,
} from "react";
import api from "../../lib/axios";
import { toast } from "react-hot-toast";
import { User } from "../interfaces/User";

interface AuthContextType {
  user: User | null;
  loading: boolean;
  login: (credentials: LoginCredentials) => Promise<void>;
  logout: () => Promise<void>;
}

interface LoginCredentials {
  username: string;
  password: string;
}

interface AuthProviderProps {
  children: ReactNode;
}

// const NEXT_JWT_EXPIRES_IN = process.env.NEXT_PUBLIC_JWT_EXPIRES_IN;
const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  const fetchUser = async () => {
    try {
      const response = await api.get<User>("/auth/me");
      setUser(response.data);
    } catch (error) {
      toast.error(`Failed to fetch user data: ${error}`);
      setUser(null);
    } finally {
      setLoading(false);
    }
  };

  const login = async (credentials: LoginCredentials) => {
    await api.post("/api/auth/login", credentials);
    await fetchUser();
  };

  const logout = async () => {
    await api.post("/api/auth/logout");
    setUser(null);
  };

  const checkTokenExpiration = useCallback(async () => {
    try {
      const response = await api.get<{ Expires: string }>(
        "/api/auth/token-info"
      );
      const expires = new Date(response.data.Expires).getTime();
      const now = Date.now();
      if (expires - now < 5 * 60 * 1000) {
        await api.post("/api/auth/refresh");
        await fetchUser();
      }
    } catch (error) {
      console.error("Token check failed:", error);
      setUser(null);
    }
  }, []);

  useEffect(() => {
    fetchUser();
    const interval = setInterval(checkTokenExpiration, 60 * 1000);
    return () => clearInterval(interval);
  }, [checkTokenExpiration]);

  return (
    <AuthContext.Provider value={{ user, loading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook
export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
