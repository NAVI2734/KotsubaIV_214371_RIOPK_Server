from app.presentation.dependencies import create_access_token
from app.presentation.dependencies import SECRET_KEY
import jwt

def test_create_access_token():
    data = {"sub": "testuser"}
    token = create_access_token(data)
    decoded = jwt.decode(token, SECRET_KEY, algorithms=["HS256"])
    assert decoded["sub"] == "testuser"
