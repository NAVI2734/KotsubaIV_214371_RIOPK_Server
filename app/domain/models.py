from pydantic import BaseModel, EmailStr
from typing import Optional


class UserBase(BaseModel):
    email: EmailStr
    full_name: Optional[str] = None
    role: str = "client"  # "client", "staff", "admin"


class UserCreate(UserBase):
    password: str


class UserInDB(UserBase):
    hashed_password: str


class UserLogin(BaseModel):
    email: EmailStr
    password: str


class Token(BaseModel):
    access_token: str
    token_type: str
