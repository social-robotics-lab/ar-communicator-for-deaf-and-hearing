import { initializeApp } from "firebase/app";
// import { getAnalytics } from "firebase/analytics";
import { getDatabase } from "firebase/database";

const apiKey=import.meta.env.VITE_FIREBASE_APIKEY;
const authDomain=import.meta.env.VITE_FIREBASE_AUTHDOMAIN;
const databaseURL=import.meta.env.VITE_FIREBASE_DATABASEURL;
const projectId=import.meta.env.VITE_FIREBASE_PROJECTID;
const storageBucket=import.meta.env.VITE_FIREBASE_STORAGEBUCKET;
const messagingSenderId=import.meta.env.VITE_FIREBASE_MESSAGINGSENDERID;
const appId=import.meta.env.VITE_FIREBASE_APPID;
const measurementId=import.meta.env.VITE_FIREBASE_MEASUREMENTID;

const firebaseConfig = {
  apiKey: apiKey,
  authDomain: authDomain,
  databaseURL: databaseURL,
  projectId: projectId,
  storageBucket: storageBucket,
  messagingSenderId: messagingSenderId,
  appId: appId,
  measurementId: measurementId
};

const app = initializeApp(firebaseConfig);
// const analytics = getAnalytics(app);

export const db = getDatabase(app);