import * as yup from "yup";

export const CreateCharacterValidationSchema = yup.object().shape({
    name: yup.string().required(),
    classId: yup.number().required("A class must be specified").min(1, "A class must be specified").max(10),
    assignToMe: yup.boolean().notRequired()
});