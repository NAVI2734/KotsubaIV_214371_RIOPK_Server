from fastapi.testclient import TestClient
from app.main import app

client = TestClient(app)

def test_access_protected_route():
    # Получаем токен
    login = client.post("/login", data={
        "grant_type": "password",
        "username": "integration@example.com",
        "password": "test123"
    })
    token = login.json()["access_token"]

    # Доступ к защищённому эндпоинту
    headers = {"Authorization": f"Bearer {token}"}
    response = client.get("/me", headers=headers)
    assert response.status_code == 200
    assert "user" in response.json()
    assert response.json()["user"]["email"] == "integration@example.com"
