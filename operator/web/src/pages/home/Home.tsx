import { useContext } from "react";
import UserSelectButton from "../../components/userSelectButton/UserSelectButton";
import "./Home.css"
import { UsersInfoContext } from "../../providers/UsersInfoProvider";

const Home:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    return(
        <div id="home">
            <h2>ユーザーを選択してください</h2>
            <div className="buttons">
                {Object.keys(usersInfo).map((userKey,index)=>{
                    return(
                        <UserSelectButton 
                            key={index}
                            userKey={userKey}
                            isDHH={userKey==="user1"||userKey==="user2"||userKey==="user3"?usersInfo[userKey]["isDHH"]:undefined}
                            gender={userKey==="user1"||userKey==="user2"||userKey==="user3"?usersInfo[userKey]["gender"]:undefined} 
                        />
                    )
                })}
            </div>
        </div>
    )
};

export default Home;