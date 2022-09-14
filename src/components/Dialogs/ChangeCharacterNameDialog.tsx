import React from "react";
import {CreateCharacterParameters} from "../../core/characters";
import ModalFormLayout from "../Layouts/ModalFormLayout";
import {ChangeCharacterNameValidationSchema, CreateCharacterValidationSchema} from "../../domain/validation";
import {useWowClasses} from "../../utils/hooks/useWowClasses";
import {Stack} from "@mui/material";
import FormikTextField from "../Formik/FormikTextField";
import FormikSelect from "../Formik/FormikSelect";
import {ChangeCharacterNameRequest} from "../../domain/requests";
import {Character} from "../../domain/models";
import {useModal} from "../../utils/modal";

export interface ChangeCharacterNameDialogProps {
    character: Character;
    onSubmit(value: ChangeCharacterNameRequest): Promise<void>
}

function ChangeCharacterNameDialog(props: ChangeCharacterNameDialogProps) {
    const {hideModal} = useModal();
    const initialValues: ChangeCharacterNameRequest = {
        characterId: props.character.id,
        name: props.character.name
    }
    async function handleSubmit(formData: ChangeCharacterNameRequest){
        if(formData.name.toUpperCase() === props.character.name.toUpperCase()){
            hideModal();
            return;
        }
        await props.onSubmit(formData);
    }
    return (
        <ModalFormLayout initialValues={initialValues} onSubmit={handleSubmit}
                         validationSchema={ChangeCharacterNameValidationSchema} title={"Update Character Name"}>
            <Stack spacing={2}>
                <FormikTextField name={"name"} label={"Choose your character name"}
                                 helperText={"Must be a valid WoW character name"} type={"text"}/>
            </Stack>
        </ModalFormLayout>

    );
}

export default React.memo(ChangeCharacterNameDialog);