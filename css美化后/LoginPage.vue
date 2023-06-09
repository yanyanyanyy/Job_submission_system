<template>
    <div class="login">
        <div class="relative">
            <div class="left">
                <el-row>
                    <el-col :span="24">
                        <div class="homepageLogo">
                            <ul>
                                <li>
                                    <el-image style="width: 50px; height: 50px" :src="url" fit="fit" />
                                </li>
                                <li><span>作业提交系统</span></li>
                            </ul>
                        </div>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <el-image class="boxbg" :src="boxbg" fit="fit" />
                        <p class="p1">欢迎使用本系统</p>
                    </el-col>
                </el-row>
            </div>
            <div class="right">
                <el-row>
                    <el-col :span="24">
                        <h2>登录</h2>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <el-form :model="form" label-width="120px" label-position="top" size="large" class="form"
                            :rules="rules" ref="ruleFormRef">
                            <!--rules为表单验证规则，以下校验两个-->
                            <el-form-item label="用户名" prop="userName">
                                <el-input v-model="form.userName" />
                            </el-form-item>
                            <el-form-item label="密码" prop="passWord">
                                <el-input v-model.number="form.passWord" type="password" show-password
                                    />
                            </el-form-item>
                            <el-form-item>
                                <el-button class="submitBtn" type="primary" @click="onSubmit(ruleFormRef)">登录
                                </el-button>
                            </el-form-item>
                        </el-form>
                    </el-col>
                </el-row>
            </div>
        </div>
    </div>
</template>
<script lang="ts" setup>
import { reactive, ref } from 'vue'
import type { FormInstance, FormRules } from 'element-plus'
//import store from '../../store/index'
//import { useRouter } from 'vue-router';
//import { getUser } from '../../http';
//const router = useRouter()
const url = ref('/images/logo.jpg')
const boxbg = ref('/images/svgs/login-box-bg.svg')
const form = reactive({
    userName: '',
    passWord: ''
})
const ruleFormRef = ref<FormInstance>()
const rules = reactive<FormRules>({
     userName: [{ required: true, message: '请输入用户名', trigger: 'blur' }],
     passWord: [{ required: true, message: '请输入密码', trigger: 'blur', type: "number" }]
 })
//接口部分：
const onSubmit = async (ruleFormRef: FormInstance | undefined) => {
    if (!ruleFormRef) return;
    //校验逻辑
     await ruleFormRef.validate(async (valid, fields) => {
         if (valid) {
            console.log("正在登录...")
            //  let userId = (await getUser(form.userName, form.passWord)).data as number
            //  ElMessage.success("登录成功！") 
            //  // 设置pinia中的值
            //  store().EditUserId(userId)
            //  router.push({ path: "/" })
         } else {
            console.log("校验不通过！ ")
            console.log(fields)
            //  let errors: string = ""
            //  fields?.userName?.forEach(element => {
            //      errors += element.message + ';'
            //  });
            //  fields?.passWord?.forEach(element => {
            //      errors += element.message + ';'
            //  });
            //  ElMessage.error(errors)
         }
     })

}
</script>
<style lang="scss" scoped>
.login {
    width: 100%;
    height: 100%;

    .relative {
        width: 100%;
        height: 100%;
        text-align: center;

        .left {
            width: 50%;
            height: 100%;
            float: left;
            background-image: url('/images/svgs/login-bg.svg');

            .boxbg {
                width: 300px;
                height: 350px;
                margin-top: 100px;
            }

            .homepageLogo {
                height: 50px;
                line-height: 50px;
                margin-top: 40px;

                span {
                    color: white;
                    font-size: 24px;
                }

                ul {
                    list-style: none;

                    li {
                        float: left;
                        margin-left: 5px;
                    }
                }
            }

            p {
                color: white;
            }

            .p1 {
                font-size: 1.875rem;
                line-height: 2.25rem;
            }

            .p2 {
                font-size: 0.875rem;
                line-height: 1.25rem;
            }
        }

        .right {
            width: 50%;
            float: left;
            padding-top: 15%;

            .form {
                width: 50%;
                margin: 0px auto;

                .submitBtn {
                    width: 100%;
                }
            }
        }
    }
}
</style>