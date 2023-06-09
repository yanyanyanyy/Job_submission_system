import axios from 'axios'        //���� axios��

/* 2.ȫ��Ĭ������ */
let baseURL
baseURL = 'https://localhost:7294/'

// ����axios������
axios.defaults.timeout = 600000;    // ����ʱʱ��1����                  
axios.defaults.baseURL = baseURL; // ��Ľӿڵ�ַ 
axios.defaults.responseType = "json";
//axios.defaults.withCredentials = false;  //�Ƿ�������cookie��Щ
axios.defaults.maxContentLength = 10000000000;
axios.defaults.crossDomain = true
export default axios 