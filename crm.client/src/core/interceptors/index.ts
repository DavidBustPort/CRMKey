import type { AxiosInstance } from 'axios'
import { apiInstance } from '../services'
import responseInterceptor from './responseInterceptor'
import requestInterceptor from './requestInterceptor'

export const setupInterceptors = (): AxiosInstance => {
    apiInstance.interceptors.request.use(requestInterceptor)
    apiInstance.interceptors.response.use((response) => response, responseInterceptor)
    return apiInstance

}
