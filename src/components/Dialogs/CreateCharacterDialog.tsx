import React from "react";
import {CreateCharacterParameters} from "../../core/characters";
import ModalFormLayout from "../Layouts/ModalFormLayout";
import {CreateCharacterValidationSchema} from "../../domain/validation";
import {useWowClasses} from "../../utils/hooks/useWowClasses";
import {Stack} from "@mui/material";
import FormikTextField from "../Formik/FormikTextField";
import FormikSelect from "../Formik/FormikSelect";

export interface CreateCharacterDialogProps {
    onSubmit(value: CreateCharacterParameters): Promise<void>
}

function CreateCharacterDialog(props: CreateCharacterDialogProps) {
    const classOptions = useWowClasses();
    const initialValues: CreateCharacterParameters = {
        classId: 1,
        name: ""
    }
    return (
        <ModalFormLayout initialValues={initialValues} onSubmit={(val) => props.onSubmit(val)}
                         validationSchema={CreateCharacterValidationSchema} title={"Add Character"}>
            <Stack spacing={2}>
                <FormikTextField name={"name"} label={"Choose your character name"}
                                 helperText={"Must be a valid WoW character name"} type={"text"}/>
                <FormikSelect name={"classId"}
                              label={"Character Class"}
                              items={classOptions.map((opt) => ({
                                  value: opt.id,
                                  content: opt.name
                              }))}/>
            </Stack>
        </ModalFormLayout>

    );
}

export default React.memo(CreateCharacterDialog);