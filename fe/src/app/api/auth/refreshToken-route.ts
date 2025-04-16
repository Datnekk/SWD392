import axios from "axios";
import { NextResponse } from "next/server";

const NEXT_PUBLIC_BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;

export async function POST() {
  try {
    const response = await axios.post(
      `${NEXT_PUBLIC_BASE_URL}/auth/refresh`,
      {}
    );

    return NextResponse.json(response.data, { status: response.status });
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      return NextResponse.json(
        { error: error.response?.data?.message || "Refersh Token failed" },
        { status: error.response?.status || 500 }
      );
    }
    return NextResponse.json(
      { error: "An unexpected error occurred" },
      { status: 500 }
    );
  }
}
