# AR Communicator For Deaf and Hearing

### 対応デバイス
* Meta Quest3

# 📚 Docs
* [:rocket: クイックスタート](#rocket-クイックスタート)
    * [:diamond_shape_with_a_dot_inside: Unityをインストールする](#diamond_shape_with_a_dot_inside-unityをインストールする)
    * [:file_folder: プロジェクトを追加する](#file_folder-プロジェクトを追加する)
    * [:fire: Firebaseプロジェクトを作成する](#fire-firebaseプロジェクトを作成する)
    * [:fire: Firebase Realtime Databaseを作成する](#fire-firebase-realtime-databaseを作成する)
    * [:robot: AndroidアプリをFirebaseに登録する](#robot-androidアプリをfirebaseに登録する)
    * [:wrench: Firebase構成ファイルを追加する](#wrench-firebase構成ファイルを追加する)
    * [:toolbox: Firebase Unity SDKを追加する](#toolbox-firebase-unity-sdkを追加する)
    * [:package: 依存パッケージをインポートする](#package-依存パッケージをインポートする)
* [:technologist: 操作画面の使用方法](Documents/Operator/README.md)


# :rocket: クイックスタート

## :diamond_shape_with_a_dot_inside: Unityをインストールする
1. [Download the Unity Hub｜Unity](https://unity.com/ja/download) からUnity Hubをダウンロードします。
2. [Unity download archive｜Unity](https://unity.com/ja/releases/editor/archive) で **2022.3.29f1** バージョンのUnityをインストールします。
3. Meta Quest用にビルドするために以下のモジュールを追加します。
    * Android Build Support ( Android SDK & NDK Tools, OpenJDK )


## :file_folder: プロジェクトを追加する
1. このリポジトリをクローンします。
    ```
    git clone https://github.com/social-robotics-lab/ar-communicator-for-deaf-and-hearing.git
    ```
2. Unity HubのProjectsで、[Add] をクリックします。
3. ARCommunicatorフォルダを選択して、作成されたプロジェクトを開きます。

## :fire: Firebaseプロジェクトを作成する
[Firebaseプロジェクトを作成する｜Firebaseドキュメント](https://firebase.google.com/docs/unity/setup?hl=ja#create-firebase-project) を参考にして、Firebaseプロジェクトを作成します。

1. [Firebaseコンソール](https://console.firebase.google.com/?hl=ja) で [プロジェクトを追加] をクリックします。
2. 任意のプロジェクト名を入力して、[続行] をクリックします。
3. Googleアナリティクスを有効にして、Firebaseプロジェクトを作成します。
4. 処理が完了すると、FirebaseコンソールにFirebaseプロジェクトの概要ページが表示されます。

## :fire: Firebase Realtime Databaseを作成する
[データベースを作成する｜Firebaseドキュメント](https://firebase.google.com/docs/database/unity/start?hl=ja#create_a_database) を参考にして、Firebase Realtime Databaseを作成します。

1. プロジェクトの概要ページの [構築] から [Realtime Database] を選択します。
2. セキュリティルールで [テストモード] を選択します。

    ※セキュリティルールについての詳細は、[Firebase Realtime Databaseセキュリティルールを理解する｜Firebaseドキュメント](https://firebase.google.com/docs/database/security?hl=ja) を参照してください。

3. 任意のデータベースのロケーションを選択して、[完了] をクリックします。
4. 下記のようにデータベースを設定します。

    ![RealtimeDatabase](Documents/Images/RealtimeDatabase.png)

## :robot: AndroidアプリをFirebaseに登録する
[アプリをFirebaseに登録する｜Firebaseドキュメント](https://firebase.google.com/docs/unity/setup?hl=ja#register-app) を参考にして、AndroidアプリをFirebaseに登録します。

1. プロジェクトの概要ページの中央で、[Unityアイコン] をクリックして設定ワークフローを起動します。
2. [Androidアプリとして登録] にチェックを入れます。
3. Androidパッケージ名に `com.DefaultCompany.ARCommunicator` と入力します。
4. アプリのニックネームに任意のアプリ名を入力して、[アプリを登録] をクリックします。

## :wrench: Firebase構成ファイルを追加する
[Firebase構成ファイルを追加する｜Firebaseドキュメント](https://firebase.google.com/docs/unity/setup?hl=ja#add-config-file) を参考にして、Firebase構成ファイルを追加します。

1. Firebaseコンソールで`google-services.json` をダウンロードします。
2. Unityプロジェクトで、`Assets`フォルダの中に`StreamingAssets`フォルダを作成します。
3. `StreamingAssets`フォルダの中に `google-services.json`を移動します。

## :toolbox: Firebase Unity SDKを追加する
[Firebase Unity SDK を追加する｜Firebaseドキュメント](https://firebase.google.com/docs/unity/setup?hl=ja#add-sdks) を参考にして、Firebase Unity SDKを追加します。

1. Firebaseコンソールで`Firebase Unity SDK` をダウンロードし、SDKを解凍します。
2. Unityプロジェクトで、[Assets] > [Import Package] > [Custom Package] を選択します。
3. 解凍したSDKから、以下のFirebaseプロダクトを選択します。

    * FirebaseAnalytics.unitypackage
    * FirebaseDatabase.unitypackage

4. Import Unity Package ウィンドウで [Import] をクリックします。

## :package: 依存パッケージをインポートする
* [UniVRM (v0.123.0)](https://github.com/vrm-c/UniVRM/releases/tag/v0.123.0) の **VRM 0.x Import/Export** via UnityPackage からパッケージをダウンロードして、Unityプロジェクトにインポートします。
