import * as yup from "yup";

export const CreateCharacterValidationSchema = yup.object().shape({
    name: yup.string().required(),
    classId: yup.number().required().min(1).max(10),
    assignToMe: yup.boolean().notRequired()
});