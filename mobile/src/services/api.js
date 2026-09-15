import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:3007/tcc_mobile",
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

api.interceptors.request.use(
  (config) => {
    console.log(
      `SPORTCORP API: ${config.method?.toUpperCase()} ${config.url}`
    );

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    console.log(
      "SPORTCORP API ERRO:",
      error.response?.data || error.message
    );

    return Promise.reject(error);
  }
);

export default api;