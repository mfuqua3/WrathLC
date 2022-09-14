import React, {useEffect, useState} from "react";
import CardPresentationLayout from "../../components/Layouts/CardPresentationLayout";
import useUserCharacters from "../../core/characters/useUserCharacters";
import LoadingWrapper from "../../components/UtilityWrappers/LoadingWrapper";
import {Character} from "../../domain/models";
import {useSearchParams} from "react-router-dom";
import WishlistsProvider from "../../core/wishlists/WishlistsProvider";
import {NoCharacters} from "../../components/Onboarding";
import {MaterialSelect} from "../../components/Formik";
import {MenuItem, Select} from "@mui/material";
import Wishlists from "../../components/Wishlists/Wishlists";

function UserWishlists() {
    const {characters} = useUserCharacters();
    const [activeCharacter, setActiveCharacter] = useState<number | null>();
    const [searchParams, setSearchParams] = useSearchParams();
    useEffect(() => {
        if (characters === undefined) {
            return;
        }
        if (characters.length === 0) {
            setActiveCharacter(null);
            return;
        }
        const queryCharacter = searchParams.get("character");
        const activeCharacter = (queryCharacter ? characters.find(x => x.name.toUpperCase() == queryCharacter.toUpperCase()) : undefined) ?? characters[0];
        setActiveCharacter(activeCharacter.id);
    }, [characters])
    
    function handleCharacterChange(val: number) {
        setActiveCharacter(val);
    }
    
    return (
        <CardPresentationLayout title={"Your Wishlists"} action={
            characters && activeCharacter &&
             <Select value={activeCharacter}
                     sx={{minWidth: 125}}
                     onChange={(e)=>handleCharacterChange(+e.target.value)}
                     disabled={characters.length <= 1}>
                 {characters.map(character =>
                     <MenuItem key={character.id} value={character.id}>{character.name}</MenuItem>)
                 }
             </Select>
        }>
            <LoadingWrapper renderChildren={false}
                            text={"Loading Character Wishlists..."}
                            loading={activeCharacter === undefined}>
                {
                    activeCharacter ?
                        <WishlistsProvider characterId={activeCharacter}>
                            <Wishlists />
                        </WishlistsProvider> :
                        <NoCharacters />
                }
            </LoadingWrapper>
        </CardPresentationLayout>

    );
}

export default React.memo(UserWishlists);