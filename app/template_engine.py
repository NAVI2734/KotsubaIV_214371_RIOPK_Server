from fastapi.templating import Jinja2Templates
import os

CLIENT_BASE_DIR = "C:/Users/NAVI/RIOPK/KotsubaIV_214371_RIOPK_Client/app"
TEMPLATES_DIR = os.path.join(CLIENT_BASE_DIR, "templates")

templates = Jinja2Templates(directory=TEMPLATES_DIR)
