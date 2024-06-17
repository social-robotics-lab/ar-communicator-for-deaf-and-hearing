import { useContext } from "react";
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";
import { UsersInfoContext } from "../../providers/UsersInfoProvider";

const User3:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    return(
        <div className="user">
            <UserHeader userIndex={3} isDHH={usersInfo.user3.isDHH} />
            <div>
                <ScenarioButton scenario="シナリオ" />
            </div>
        </div>
    )
};

export default User3;