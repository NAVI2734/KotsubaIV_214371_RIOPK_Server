from fastapi import FastAPI
from app.presentation.routes import router

# Создание приложения FastAPI
app = FastAPI(title="Центр социального обслуживания")

# Подключаем маршруты
app.include_router(router)

# Комментарий: точка входа в API
