/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_MOCK_USERROLE: string
    readonly VITE_MODE_SIANCENTRAL: string
    readonly VITE_BASE_URL: string
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}
