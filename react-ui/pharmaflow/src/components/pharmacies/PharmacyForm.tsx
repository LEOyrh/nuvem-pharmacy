import { useEffect } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom"
import { PharmacyDto } from "../../models/pharmacyDto";
import apiConnector from "../../api/apiConnector";
import { Button, Form, FormInput, Segment } from "semantic-ui-react";
import * as Yup from 'yup';
import { useFormik } from 'formik';

export default function PharmacyForm() {

    const { id } = useParams();
    const navigate = useNavigate();

    const initialValues: PharmacyDto = {
        pharmacyId: undefined,
        name: '',
        address: '',
        city: '',
        state: '',
        zip: '',
        numberOfFilledPrescriptions: 0,
        createdDate: new Date(),
        updatedDate: new Date()
    };

    const validationSchema = Yup.object().shape({
        name: Yup.string().required('Name is required'),
        address: Yup.string().required('Address is required'),
        city: Yup.string()
            .required('City is required')
            .max(50, 'City cannot be more than 50 characters'),
        state: Yup.string()
            .required('State is required')
            .max(2, 'State cannot be more than 2 characters'),
        zip: Yup.string()
            .required('Zip is required')
            .matches(/^\d+$/, 'Zip must be numeric'),
        numberOfFilledPrescriptions: Yup.number()
            .integer('Filled Prescriptions must be an integer')
            .min(0, 'Filled Prescriptions cannot be less than 0')
    });

    const formik = useFormik({
        initialValues,
        validationSchema,
        onSubmit: (pharmacy) => {
            const submitPharmacy = {
                ...pharmacy,
                state: pharmacy.state.toUpperCase(), // Transform State to uppercase
                numeOfFilledPrescriptions: pharmacy.numberOfFilledPrescriptions || 0 // Ensure numberOfFilledPrescriptions has a value
            };

            if (!submitPharmacy.pharmacyId) {
                apiConnector.createPharmacy(submitPharmacy).then(() => navigate('/'));
            } else {
                apiConnector.editPharmacy(submitPharmacy).then(() => navigate('/'));
            }
        }
    });

    useEffect(() => {
        if (id) {
            apiConnector.getPharmacyById(id).then(pharmacy => {
                if (pharmacy) {
                    formik.setValues(pharmacy!);
                }
            });
        }
        // eslint-disable-next-line
    }, [id]);

    return (
        <Segment clearing inverted>
            <Form onSubmit={formik.handleSubmit} autoComplete='off' inverted>
                <FormInput label='Name' placeholder='Name' name='name' value={formik.values.name} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.name && formik.errors.name ? { content: formik.errors.name } : null} />
                <FormInput label='Address' placeholder='Address' name='address' value={formik.values.address} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.address && formik.errors.address ? { content: formik.errors.address } : null} />
                <FormInput label='City' placeholder='City' name='city' value={formik.values.city} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.city && formik.errors.city ? { content: formik.errors.city } : null} />
                <FormInput label='State' placeholder='State' name='state' value={formik.values.state} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.state && formik.errors.state ? { content: formik.errors.state } : null} />
                <FormInput label='Zip' placeholder='Zip' name='zip' value={formik.values.zip} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.zip && formik.errors.zip ? { content: formik.errors.zip } : null} />
                <FormInput label='Filled Prescriptions' placeholder='FilledPrescriptions' name='numberOfFilledPrescriptions' value={formik.values.numberOfFilledPrescriptions} onChange={formik.handleChange} onBlur={formik.handleBlur} error={formik.touched.numberOfFilledPrescriptions && formik.errors.numberOfFilledPrescriptions ? { content: formik.errors.numberOfFilledPrescriptions } : null} />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button as={NavLink} to='/' floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}