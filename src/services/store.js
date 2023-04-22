import { configureStore } from "@reduxjs/toolkit";
import { authApi } from "./apis/auth.api";
import authReducer from "./slices/auth.slice";
import registrationReducer from "./slices/registration.slice";
import chatReducer from "./slices/chat.slice";
import { chatApi } from "./apis/chat.api";

const store = configureStore({
    reducer: {
        auth: authReducer,
        registration: registrationReducer,
        chat: chatReducer,
        [authApi.reducerPath]: authApi.reducer,
        [chatApi.reducerPath]: chatApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(authApi.middleware, chatApi.middleware),
});

export default store;
