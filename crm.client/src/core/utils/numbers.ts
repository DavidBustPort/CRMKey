export const formatCurrency = (value: number, decimals: number = 2) => {
    return new Intl.NumberFormat('es-MX', {
        style: 'currency',
        currency: 'MXN',
        minimumFractionDigits: decimals,
        maximumFractionDigits: decimals
    }).format(value)
}
