# AR Communicator For Deaf and Hearing

### 対応デバイス
* Meta Quest3

## 🔧 Setup
### Unityをインストールする
[Download Unity](https://unity.com/ja/download)の手順に沿ってUnityをインストールする
#### Unityバージョン
* 20223.29f1
#### モジュール
* Android Build Support ( Android SDK & NDK Tools / OpenJDK )

### Dockerをインストールする
[Docker Desktop](https://www.docker.com/ja-jp/products/docker-desktop/)からDockerをインストールする

## 🚀 Quick Start
### Unity
1. Unity HubのProjectsで、Addをクリックする
2. ARCommunicatorフォルダを選択する

### 操作画面
1. operatorフォルダに移動する
    ```
    cd operator/
    ```
2. Dockerコンテナをビルド・起動する
    ```
    docker compose up --build
    ```
3. http://localhost:5173/ にアクセスする
    