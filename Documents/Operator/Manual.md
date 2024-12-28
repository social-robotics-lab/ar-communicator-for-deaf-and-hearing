# :book: 操作画面マニュアル
* [セットアップ](#セットアップ)
* [ユーザについて](#ユーザについて)
* [シナリオファイルについて](#シナリオファイルについて)
* [各ユーザ操作画面のボタンについて](#各ユーザ操作画面のボタンについて)

## セットアップ
セットアップの手順は[README](README.md)の通りです。

## ユーザについて
* システムの使用ユーザは３人を想定しています。各ユーザ操作画面は、ホームページの [user1] [user2] [user3] のボタンから移動できます。
* ホームページに記載されている `user1` `user2` `user3` は Firebase Realtime Database の `user1` `user2` `user3` と紐づいています。

## シナリオファイルについて
![ScenarioFileExample](Images/ScenarioFileExample.png)

* `id`：１から昇順の数値
* `user`：発話するユーザ番号（1~3）。Firebase Realtime Database のユーザ番号（`user1` `user2` `user3`）と紐づいています。
* `message`：ユーザが話す内容。ここに書いた内容が操作画面のボタンに表示される文字列と Firebse Realtime Database に送信される文字列になります。

## 各ユーザ操作画面のボタンについて
* ボタンをクリックするとFirebase Realtime Database にボタンに表示された文字列が送信されます。