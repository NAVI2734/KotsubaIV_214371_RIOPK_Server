from sqlalchemy import Column, Integer, String, DateTime, ForeignKey
from sqlalchemy.orm import relationship, declarative_base
from datetime import datetime

Base = declarative_base()

class User(Base):
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True)
    email = Column(String, unique=True, index=True, nullable=False)
    full_name = Column(String, nullable=False)
    hashed_password = Column(String, nullable=False)
    role = Column(String, default="client")

    requests = relationship("Request", back_populates="owner")
    actions = relationship("StaffAction", back_populates="staff")


class Request(Base):
    __tablename__ = "requests"

    id = Column(Integer, primary_key=True, index=True)
    title = Column(String, nullable=False)
    description = Column(String, nullable=True)
    status = Column(String, default="pending")
    created_at = Column(DateTime, default=datetime.utcnow)

    user_id = Column(Integer, ForeignKey("users.id"))
    owner = relationship("User", back_populates="requests")

    actions = relationship("StaffAction", back_populates="request")


class StaffAction(Base):
    __tablename__ = "staff_actions"

    id = Column(Integer, primary_key=True, index=True)
    action_type = Column(String, nullable=False)
    timestamp = Column(DateTime, default=datetime.utcnow)

    staff_id = Column(Integer, ForeignKey("users.id"))
    request_id = Column(Integer, ForeignKey("requests.id"))

    staff = relationship("User", back_populates="actions")
    request = relationship("Request", back_populates="actions")
