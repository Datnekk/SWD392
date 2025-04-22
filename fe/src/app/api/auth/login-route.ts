import axios from "axios";
import { NextResponse } from "next/server";

const NEXT_PUBLIC_BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;

export async function POST(request: Request) {
  try {
    const { email, password } = await request.json();

    if (!email || !password) {
      return NextResponse.json(
        { error: "Email and password are required" },
        { status: 400 }
      );
    }

    const response = await axios.post(`${NEXT_PUBLIC_BASE_URL}/auth/login`, {
      email,
      password,
    });

    return NextResponse.json(response.data, { status: response.status });
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      return NextResponse.json(
        { error: error.response?.data?.message || "Login failed" },
        { status: error.response?.status || 500 }
      );
    }
    return NextResponse.json(
      { error: "An unexpected error occurred" },
      { status: 500 }
    );
  }
}
