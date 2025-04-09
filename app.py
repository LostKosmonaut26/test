from flask import Flask, render_template, request
import requests

web = Flask(__name__)

@web.route('/')
def index():
    return render_template('index.html')

@web.route('/submit', methods=['POST'])
def submit():
    name=request.form["textbox1"]
    password=request.form["textbox2"]
    data_json={"name":name,
               "password":password}
    print(data_json)
    response=requests.post("http://127.0.0.1:6000/api/submit",json=data_json)
    return "ok"

if __name__ == '__main__':
    web.run(port=5000, debug=True)
