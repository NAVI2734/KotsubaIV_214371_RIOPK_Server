from fastapi import APIRouter, Request
from fastapi.responses import HTMLResponse
from app.template_engine import templates

router = APIRouter()

@router.get("/", response_class=HTMLResponse)
def root(request: Request):
    print("✅ / (корневой маршрут) вызван")
    return templates.TemplateResponse("login.html", {"request": request})

@router.get("/test", response_class=HTMLResponse)
def test_route(request: Request):
    print("✅ /test вызван")
    return templates.TemplateResponse("login.html", {"request": request})
