import "./UserHeader.css"

const UserHeader:React.FC<{userIndex:number,isDHH:boolean}>=({userIndex,isDHH})=>{
    return(
        <div id="userHeader">
            <h2>User{userIndex}</h2>
            <div>
                {isDHH?<p>手話 🙌 → 音声 🔈</p>:<p>音声 🔈 → 手話 🙌</p>}
            </div>
        </div>
    )
};

export default UserHeader;