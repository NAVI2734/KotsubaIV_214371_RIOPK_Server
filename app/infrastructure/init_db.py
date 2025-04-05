from app.infrastructure.database import engine
from app.infrastructure.models import Base

def init_db():
    Base.metadata.create_all(bind=engine)

if __name__ == "__main__":
    init_db()
    print("✅ База данных и таблицы успешно созданы.")
