import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './components/App.tsx';
import './index.css';
import { createBrowserRouter, Navigate, RouterProvider } from 'react-router-dom';
import ChallengeDetail, { challengeDetailLoader } from './components/ChallengeDetail.tsx';
import ChallengeList from './components/ChallengeList.tsx';
// import CreateChallenge from './components/CreateChallenge.tsx';
import UsefulLinks from './components/UsefulLinks.tsx';

const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {
                path: '',
                element: <ChallengeList />,
            },
            {
                path: 'regex-challenges/:id',
                loader: challengeDetailLoader,
                element: <ChallengeDetail />,
            },
            // {
            //     path: 'create',
            //     element: <CreateChallenge />,
            // },
            {
                path: 'useful-links',
                element: <UsefulLinks />,
            },
            {
                path: '/*',
                element: <Navigate to={''} />,
            },
        ],
    },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);
