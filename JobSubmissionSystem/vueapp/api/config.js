import axios from 'axios'        //���� axios��
import qs from 'qs'              //���� node���Դ���qsģ�飨���ݸ�ʽת����

/* 2.ȫ��Ĭ������ */
let baseURL
// �жϿ���������һ�����ڱ��ش���
baseURL = 'https://localhost:7294/'

// ����axios������
axios.defaults.timeout = 6000;    // ����ʱʱ��1����                  
axios.defaults.baseURL = baseURL; // ��Ľӿڵ�ַ 
axios.defaults.responseType = "json";
axios.defaults.withCredentials = false;  //�Ƿ������cookie��Щ

export default axios 