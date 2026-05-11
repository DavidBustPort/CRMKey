export const truncate = (text: string, length: number = 20, suffix: string = '...') => {
    if (!text) return ''
    if (text.length <= length) return text
    return text.substring(0, length) + suffix
}
