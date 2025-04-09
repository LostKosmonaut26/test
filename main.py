from flask import Flask, request, jsonify
from flask_jwt_extended import JWTManager, create_access_token, jwt_required, get_jwt_identity

app = Flask(__name__)
app.config["JWT_SECRET_KEY"] = "super-secret-key"

jwt = JWTManager(app)

@app.route("/login", methods=["POST"])
def login():
    username = request.json.get("username")
    password = request.json.get("password")

    # Пример простой проверки
    if username == "admin" and password == "123":
        access_token = create_access_token(identity=username)
        return jsonify(access_token=access_token)

    return jsonify({"msg": "Bad credentials"}), 401

@app.route("/protected", methods=["GET"])
@jwt_required()
def protected():
    current_user = get_jwt_identity()
    return jsonify(logged_in_as=current_user)

@app.route('/api/submit', methods=['POST'])
def handle_submit():
    
    result=request.get_json()
    
    name=result.get("name")
    password=result.get("password")
    print(f"{name},{password}")
    return "123"

if __name__ == "__main__":
    app.run(port=6000,host="0.0.0.0")
