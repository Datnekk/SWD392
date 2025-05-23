import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import ClientOnly from "@/app/components/navbar/ClientOnly";
import ToasterProvider from "./providers/ToasterProvider";
import { cn } from "@/lib/utils";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "EOS 2.0",
  description: "Better EOS",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
        <ClientOnly>
          <ToasterProvider></ToasterProvider>
        </ClientOnly>
        <div className={cn("antialiased min-h-screen pt-16")}>{children}</div>
      </body>
    </html>
  );
}
