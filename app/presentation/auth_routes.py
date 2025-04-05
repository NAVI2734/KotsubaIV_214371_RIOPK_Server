from fastapi import APIRouter, Depends, HTTPException, status
from fastapi.security import OAuth2PasswordRequestForm
from datetime import timedelta, datetime
from jose import jwt
from passlib.context import CryptContext

from .dependencies import get_current_user, SECRET_KEY, ALGORITHM, fake_users_db

router = APIRouter()
pwd_context = CryptContext(schemes=["bcrypt"], deprecated="auto")


def verify_password(plain_password, hashed_password):
    return pwd_context.verify(plain_password, hashed_password)


def get_password_hash(password):
    return pwd_context.hash(password)


def authenticate_user(username: str, password: str):
    user = fake_users_db.get(username)
    if not user or not verify_password(password, user["hashed_password"]):
        return None
    return user


def create_access_token(data: dict, expires_delta: timedelta = timedelta(minutes=15)):
    to_encode = data.copy()
    expire = datetime.utcnow() + expires_delta
    to_encode.update({"exp": expire})
    return jwt.encode(to_encode, SECRET_KEY, algorithm=ALGORITHM)


@router.post("/register")
def register(form: OAuth2PasswordRequestForm = Depends()):
    if form.username in fake_users_db:
        raise HTTPException(status_code=400, detail="Пользователь уже существует")
    hashed = get_password_hash(form.password)
    fake_users_db[form.username] = {
        "email": form.username,
        "full_name": "Пользователь",
        "hashed_password": hashed,
    }
    return {"msg": "Успешно зарегистрирован"}

@router.post("/login")
def login(form_data: OAuth2PasswordRequestForm = Depends()):
    user = authenticate_user(form_data.username, form_data.password)
    if not user:
        raise HTTPException(status_code=401, detail="Неверный логин или пароль")
    access_token = create_access_token(data={"sub": user["email"]})
    return {"access_token": access_token, "token_type": "bearer"}

@router.get("/me")
def read_users_me(current_user: dict = Depends(get_current_user)):
    return {"user": current_user}
