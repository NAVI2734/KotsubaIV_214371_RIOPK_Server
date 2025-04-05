print("🚀 Запуск main.py")
from fastapi import FastAPI
from app.presentation.routes import router
from app.presentation.auth_routes import router as auth_router
from fastapi.staticfiles import StaticFiles
import os

# Указываем внешнюю клиентскую директорию (где находятся шаблоны и статика)
CLIENT_BASE_DIR = "C:/Users/NAVI/RIOPK/KotsubaIV_214371_RIOPK_Client/app"

app = FastAPI(
    title="Центр социального обслуживания",
    debug=True
)

# Подключение статических файлов
app.mount("/static", StaticFiles(directory=os.path.join(CLIENT_BASE_DIR, "static")), name="static")

# Подключение маршрутов
app.include_router(router)
app.include_router(auth_router)
