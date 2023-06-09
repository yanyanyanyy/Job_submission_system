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
                                    <el-input v-model.number="form.passWord" type="password" show-password />
                                </el-form-item>
                                <el-form-item>
                                        <el-button class="submitBtn" type="primary" @click="onSubmit(ruleFormRef)">
                                            登录
                                        </el-button>
                                </el-form-item>
                            </el-form>
                        </el-col>
                    </el-row>
                </div>
            </div>
        </div>
    <router-view></router-view>
</template>
<script>
    import axios from '../../api/config'
    import { ElMessage, ElMessageBox } from 'element-plus'

    export default {
        name: "LoginPage",
        data() {
          return{
            url: '/images/logo.jpg',
            boxbg: '/images/svgs/login-box-bg.svg',
            form: {
                userName: '',
                passWord: ''
              },
              user: null
          }    
        },
        methods: {
            onSubmit(e) {
                if (this.form.userName == "" || this.form.passWord == "") {
                    ElMessage({
                        type: 'error',
                        message: '密码不能为空',
                    })
                    return
                }
                axios({
                    method: 'POST',
                    url: 'api/login',
                    params: {
                        username: this.form.userName,
                        password: this.form.passWord
                    }
                })
                .then(response => {
                    this.user = response.data
                    if (this.user.userType == -1)
                        ElMessage({
                            type: 'error',
                            message: '密码错误',
                        })
                    else {
                        ElMessage({
                            type: 'success',
                            message: '密码正确',
                        })
                        this.$cookies.set("userInfo",this.user)
                        if (this.user.userType == 0) {
                            this.$router.push('/TeacherCorrectPage')
                        }
                        else if(this.user.userType == 1) {
                            this.$router.push('/StudentCorrectListPage')
                        }
                    }
                    return response.data
                }, error => {
                    ElMessage({
                        type: 'error',
                        message: '未知的错误，请联系管理员',
                    })
                })

            }
        }
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
            height: 98vh;
            float: left;
            background-image: url('../../public/images/svgs/login-bg.svg');

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