import { useContext } from "react";
import UserSelectButton from "../../components/userSelectButton/UserSelectButton";
import "./Home.css"
import { UsersInfoContext, UsersInfoType } from "../../providers/UsersInfoProvider";

const Home:React.FC=()=>{
    const {usersInfo,setUsersInfo}=useContext(UsersInfoContext);
    
    const handleUpdateUserInfoButton=():void=>{
        // TODO:ここでFirebaseのデータ（isDHH）を取得する
        const newUserInfo:UsersInfoType={
            user1:{isDHH:false},
            user2:{isDHH:true},
            user3:{isDHH:false}
        };
        setUsersInfo(newUserInfo);
    }
    return(
        <div id="home">
            <h2>ユーザーを選択してください</h2>
            <button onClick={handleUpdateUserInfoButton} className="updateButton">ユーザー情報を更新する</button>
            <div className="buttons">
                {Object.keys(usersInfo).map((userKey,index)=>{
                    return(
                        <UserSelectButton key={index} userKey={userKey} isDHH={userKey==="user1"||userKey==="user2"||userKey==="user3"?usersInfo[userKey]["isDHH"]:undefined} />
                    )
                })}
            </div>
        </div>
    )
};

export default Home;