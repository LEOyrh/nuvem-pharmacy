import { RouteObject, createBrowserRouter } from "react-router-dom";
import PharmacyForm from "../components/pharmacies/PharmacyForm";
import PharmacyTable from "../components/pharmacies/PharmacyTable";
import App from "../App";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'createPharmacy', element: <PharmacyForm key='create' /> },
            { path: 'editPharmacy/:id', element: <PharmacyForm key='edit' /> },
            { path: '*', element: <PharmacyTable /> }

        ]
    }
]

export const router = createBrowserRouter(routes);