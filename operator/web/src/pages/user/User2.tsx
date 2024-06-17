import { useContext } from "react";
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";
import { UsersInfoContext } from "../../providers/UsersInfoProvider";

const User2:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    return(
        <div className="user">
            <UserHeader userIndex={2} isDHH={usersInfo.user2.isDHH} />
            <div>
                <ScenarioButton scenario="シナリオ" />
            </div>
        </div>
    )
};

export default User2;