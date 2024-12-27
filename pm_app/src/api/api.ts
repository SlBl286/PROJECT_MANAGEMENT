import { ACCESS_TOKEN_KEY, REFRESH_TOKEN_KEY } from "@/config";
import axios, { AxiosError, AxiosResponse } from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: {
    "Content-Type": "application/json",
    "Accept": "*/*"
  },
  timeout: 60000,
  withCredentials: false,
});

api.interceptors.request.use((config: any) => {
  const token = localStorage.getItem(ACCESS_TOKEN_KEY);
  config.headers = config.headers || {};
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

api.interceptors.response.use(
  (response: AxiosResponse) => {
    return response;
  },
  (error: AxiosError) => {
    try {
      const { response } = error;
      if (response?.status === 401) {
        localStorage.removeItem(ACCESS_TOKEN_KEY);
      }
    } catch (e) {
      console.error(e);
    }
    throw error;
  }
);
api.interceptors.response.use(
  (response:AxiosResponse) => response,
  async (error) => {
    const originalRequest = error.config;
    if (error.response.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true;
      const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY);
      const { data } = await axios.post(`${import.meta.env.VITE_API_URL}/refresh`, {
        token: refreshToken,
      });
      localStorage.setItem(ACCESS_TOKEN_KEY, data.token);
      api.defaults.headers.common["Authorization"] = `Bearer ${data.token}`;
      return api(originalRequest);
    }
    return Promise.reject(error);
  }
);
export default api;
