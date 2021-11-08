import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Dashboard from './pages/client/dashboard';

import UsersCreate from './pages/client/users/users.create';
import UserPut from './pages/client/users/users.put';
import Users from './pages/client/users';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path='/' exact component={Dashboard} />

                <Route path='/users/add' exact component={UsersCreate} />
                <Route path='/client/:id' exact component={UserPut} />
                <Route path='/users' exact component={Users} />
            </Switch>
        </BrowserRouter>
    )
}