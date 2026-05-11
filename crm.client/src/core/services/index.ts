import axios, { type AxiosInstance } from 'axios'
import { ExternalSessionService as ExtSessionService } from './externalSession-service'
import { ExternalSessionMockService } from './mocks/externalSession.mock-service'

const getBaseUrl = (): string => {
    if (import.meta.env.DEV) return '/api'
    return `${import.meta.env.BASE_URL}api`
}

const apiInstance: AxiosInstance = axios.create({
    baseURL: getBaseUrl(),
    withCredentials: true,
    headers: {
        'Content-Type': 'application/json'
    }
})

const modeDev = import.meta.env.DEV

export const ExternalSessionService = modeDev
    ? ExternalSessionMockService
    : ExtSessionService

export { apiInstance }
