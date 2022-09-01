import React, {ReactNode} from "react";
import {Button} from "@mui/material";
import {Form, Formik, FormikHelpers, FormikProps} from "formik";
import {LoadingButton} from "@mui/lab";
import ModalLayout, {ModalLayoutProps} from "./ModalLayout";
import {useModal} from "../../utils/modal";

export interface ModalFormLayoutProps<T> extends ModalLayoutProps {
    initialValues: T;
    validationSchema?: unknown | (() => unknown);
    minHeight?: string;

    onSubmit(formData: T, helpers?: FormikHelpers<T>): Promise<void>;

    onCancel?(): void;
}

function ModalFormLayout<T extends object>(props: ModalFormLayoutProps<T> & { children: ReactNode }) {
    const {hideModal} = useModal();
    function handleCancel(){
        hideModal();
        if(props.onCancel){
            props.onCancel();
        }

    }
    return (
        <Formik initialValues={props.initialValues} onSubmit={props.onSubmit} validationSchema={props.validationSchema}
                enableReinitialize>
            {({isSubmitting, submitForm}: FormikProps<T>) => (
                <Form>
                    <ModalLayout {...props} actions={
                        <>
                            <Button color={"primary"} onClick={handleCancel} variant={"outlined"}>Cancel</Button>
                            <LoadingButton color={"primary"} type={"button"} onClick={submitForm}
                                           variant={"contained"} loading={isSubmitting}>
                                Submit
                            </LoadingButton>
                        </>
                    }>
                        {props.children}
                    </ModalLayout>
                </Form>
            )}
        </Formik>

    );
}

export default ModalFormLayout;
