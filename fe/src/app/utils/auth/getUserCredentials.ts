import { NextRequest } from "next/server";

export type UserCredentials = {
  refreshToken: string;
  accessToken: string;
  accessTokenExpiryTime: number;
};

export function getUserCredentials(req: NextRequest): UserCredentials | null {
  const tokens = req.cookies.get("accessToken")?.value;
  if (!tokens) return null;
  const credentials = JSON.parse(tokens) as UserCredentials;
  return credentials;
}
