import * as jwt from "jsonwebtoken";

const NEXT_JWT_SECRET = process.env.NEXT_JWT_SECRET;

export default async function isValidJWT(token: string) {
  if (!NEXT_JWT_SECRET) {
    throw new Error("JWT secret is not defined");
  }

  return new Promise((resolve) => {
    jwt.verify(token, NEXT_JWT_SECRET, function (err, payload) {
      if (err) resolve(false);
      return resolve(payload);
    });
  });
}
