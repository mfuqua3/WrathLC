import React, { useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {useAuth} from "../../utils/auth";
import LoadingWrapper from "../UtilityWrappers/LoadingWrapper";
import {Box} from "@mui/material";


function SignInCallback() {
    const navigate = useNavigate();
    const {userManager} = useAuth();
    useEffect(()=> {
        handleCallback()
            .then(()=>navigate("/"));
    },[]);
    async function handleCallback(){
        const user = await userManager.signinCallback();
        if(user){
            await userManager.storeUser(user);
        }
    }
    return (
        <LoadingWrapper loading={true}>
            <Box height={"100%"} />
        </LoadingWrapper>
    );
}

export default React.memo(SignInCallback);
