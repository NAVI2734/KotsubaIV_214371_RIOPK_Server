from app.presentation.dependencies import get_password_hash, verify_password

def test_password_hashing():
    password = "supersecret"
    hashed = get_password_hash(password)
    assert hashed != password
    assert verify_password(password, hashed)
