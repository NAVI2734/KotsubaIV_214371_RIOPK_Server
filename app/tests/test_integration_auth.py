from fastapi.testclient import TestClient
from app.main import app

client = TestClient(app)

def test_register_user():
    response = client.post("/register", data={
        "grant_type": "password",
        "username": "integration@example.com",
        "password": "test123"
    })
    assert response.status_code == 200
    assert "Успешно зарегистрирован" in response.json()["msg"]

def test_login_user():
    response = client.post("/login", data={
        "grant_type": "password",
        "username": "integration@example.com",
        "password": "test123"
    })
    assert response.status_code == 200
    assert "access_token" in response.json()
