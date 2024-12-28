# :book: マニュアル
* [セットアップ](#セットアップ)
* [ファイル構成](#ファイル構成)
* [シーケンス図](#シーケンス図)
* [データベース設計](#データベース設計)

## セットアップ
セットアップの手順は[README](../../README.md)の通りです。

## アバターの位置調整
コントローラーでアバターの位置を調整することができます。

※アバター選択の切り替えは、ボタンを押すたびにFemale1 > Female2 > Female3 > Male1 > Male2 > Male3 > Female1......のようにループします。

<img width=600 src="Images/AvatarPositonController.png">

## ファイル構成
```
Asset
└── Project
    ├── Animations
    │   ├── FemaleAnimatorController.controller #男性アバター用アニメーター
    │   ├── MaleAnimatorController.controller #女性アバター用アニメーター
    │   └── Mask #アニメーターで使用するマスク
    │   │   ├── Face.mask
    │   │   └── Upper.mask
    ├── Prefabs
    │   ├── Avatars #アバター情報
    │   │   ├── Female1 #女性アバター1
    │   │   │   ├── Avatar_F1.Avatar  #女性アバター1のオブジェクト
    │   │   │   ├── Avatar_F1.AvatarDescription
    │   │   │   ├── Avatar_F1.BlendShapes
    │   │   │   ├── Avatar_F1.Materials
    │   │   │   ├── Avatar_F1.Meshes
    │   │   │   ├── Avatar_F1.MetaObject
    │   │   │   └── Avatar_F1.Textures
    │   │   ├── Female2 #女性アバター2
    │   │   ├── Female3 #女性アバター3
    │   │   ├── Male1 #男性アバター1
    │   │   ├── Male2 #男性アバター2
    │   │   └── Male3 #男性アバター3
    │   └── Settings
    │   │   └── SettingsButton.prefab #設定画面内のボタンオブジェクト
    ├── Scenes
    │   ├── Production #本番用シーンを格納
    │   │   ├── MainScene.unity #メインのシーン
    │   │   └── SettingsScene.unity #設定画面シーン
    │   └── Test #開発用シーンを格納
    └── Scripts
        ├── Avatars
        │   ├── AllAvatarsManagerScript.cs #全アバターの管理（アバターのID振り分け等）
        │   ├── AvatarControllerScript.cs #各アバターの振る舞いを指定
        │   ├── AvatarPositionControllerScript.cs #アバターの位置調整
        │   ├── SignLanguage
        │   │   └── SignLanguageScript.cs #アバターの手話動作
        │   └── SpokenLanguage
        │       └── SpokenLanguageScript.cs #アバターの発話と発話動作
        ├── Firebase #Firebaseとのデータ受け渡し
        │   ├── GetGenderScript.cs #Gender値の取得
        │   ├── GetIsDHHScript.cs #IsDHH値の取得
        │   ├── InitializeFirebaseScript.cs #Firebase設定の初期化
        │   ├── ListenMessageChangedScript.cs #Message値の変更監視
        │   ├── SaveGenderScript.cs #Gender値の更新
        │   └── SaveIsDHHScript.cs #IsDHH値の更新
        ├── Scenario
        │   └── ScenarioToDict.cs #シナリオデータ成形
        └── Settings #設定画面のユーザ操作スクリプトを格納
            ├── OnButtonClickedScript.cs #ボタンクリック時の動作
            └── OnSelectUserButtonClickedScript.cs #ユーザ選択時の動作
```

## シーケンス図

```mermaid
sequenceDiagram
actor user1 as User1's Device
actor user2 as User2's Device
actor user3 as User3's Device
participant db as Firebase
participant ope as Operator PC

note left of user1: 設定画面
user1 ->> db: ユーザ設定を送信
user2 ->> db: ユーザ設定を送信
user3 ->> db: ユーザ設定を送信
note over user1,user3: Startボタンを押す
db ->> user1: 全ユーザ情報を送信
db ->> user2: 全ユーザ情報を送信
db ->> user3: 全ユーザ情報を送信

note over user1,user3: アバター位置調整

alt User1=聴者
note over user1: 発話
user1 -->> ope: 
note over ope: 遠隔操作（User1の発話）
ope ->> db: テキスト
alt User2=聴覚障がい者
db ->> user2: テキスト
note over user2: アバター手話動作
end
alt User3=聴覚障がい者
db ->> user3: テキスト
note over user3: アバター手話動作
end

else User1=聴覚障がい者
note over user1: 手話
user1 -->> ope: 
note over ope: 遠隔操作（User1の手話）
ope ->> db: テキスト
alt User2=聴者
db ->> user2: テキスト
note over user2: アバター発話
end
alt User3=聴者
db ->> user3: テキスト
note over user3: アバター発話
end
end

```

## データベース設計
```mermaid
erDiagram
User{
bool isDHH "true=聴覚障がい者 / false=聴者"
string gender "'m'=男性 / 'f'=女性"
string message "ユーザの発話"
}
```