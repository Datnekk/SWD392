import axios, { AxiosInstance, AxiosError } from "axios";

const NEXT_PUBLIC_BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;

const api: AxiosInstance = axios.create({
  baseURL: `${NEXT_PUBLIC_BASE_URL}`,
  withCredentials: true,
});

interface CustomAxiosError extends AxiosError {
  config: AxiosError["config"] & { _retry?: boolean };
}

api.interceptors.response.use(
  (response) => response,
  async (error: CustomAxiosError) => {
    const originalRequest = error.config;
    if (error.response?.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true;
      try {
        await api.post("/auth/refresh");
        return api(originalRequest);
      } catch (refreshError) {
        window.location.href = "/login";
        return Promise.reject(refreshError);
      }
    }
    return Promise.reject(error);
  }
);

export default api;
