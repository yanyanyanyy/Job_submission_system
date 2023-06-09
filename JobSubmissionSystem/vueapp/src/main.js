import { createApp } from 'vue'
import App from './App.vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import { createRouter, createWebHistory } from 'vue-router'
import VueCookie from 'vue-cookies'

//ע��·��
const routes = [
    {
        path: '/',
        component: () => import('./components/LoginPage')
    },
    {
        path: '/TeacherHomePage',
        component: () => import('./components/TeacherHomePage.vue')
    },
    {
        path: '/TeacherCorrectPage',
        component: () => import('./components/TeacherCorrectPage.vue')
    },
    {
        path: '/TeacherRealeasePage',
        component: () => import('./components/TeacherRealeasePage.vue')
    },
    
    {
        path: '/TeacherCorrectPage',
        component: () => import('./components/TeacherCorrectPage.vue')
    },
    {
        path: '/CorrectCodePage',
        component: () => import('./components/CorrectCodePage.vue')
    },
    {
        path: '/StudentCorrectListPage',
        component: () => import('./components/StudentCorrectListPage.vue')
    },
    {
        path: '/StudentHomePage',
        component: () => import('./components/StudentHomePage.vue')
    },
    {
        path: '/StudentUnsubmmitTaskPage',
        component: () => import('./components/StudentUnsubmmitTaskPage.vue')
    },
    {
        path: '/StudentCorrectPage',
        component: () => import('./components/StudentCorrectPage.vue')
    },

];
const router = createRouter({
    history: createWebHistory(),
    routes
});

createApp(App).use(router).use(ElementPlus).use(VueCookie).mount('#app')

