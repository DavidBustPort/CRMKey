<template>
    <div class="not-found-container">
        <div>
            <h1>404 - Página no encontrada</h1>
            <p>Lo sentimos, la página que buscas no existe.</p>
            <RouterLink to="/">Volver al inicio</RouterLink>
        </div>
    </div>
</template>

<style scoped>
.not-found-container {
    display: flex;
    align-items: center;
    justify-content: center;
    height: 80vh;
    text-align: center;
}
</style>
