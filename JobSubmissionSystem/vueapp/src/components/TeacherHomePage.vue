<template>
    <!--本页面是教师登录之后的第一个页面，实现有批改作业和发布作业两个选项，点击对应的选项会跳转到对应的页面-->
    <div class="teacherHome">
        <div class="relative">
            <div class="teacherImg">
                <h1>{{this.$cookies.get("userInfo").username}}老师欢迎您!!</h1>
            </div>
        
            <div class="bottom">
                <div class="flex justify-space-between mb-4 flex-wrap gap-4">
                    <router-link to="/TeacherCorrectPage">
                        <el-button :key="buttons[0].text"
                                   :type="buttons[0].type"
                                   text
                                   bg>{{ buttons[0].text }}</el-button>
                    </router-link>
                    <span width="10vw"></span>
                    <router-link to="/TeacherRealeasePage">
                        <el-button :key="buttons[1].text"
                                   :type="buttons[1].type"
                                   text
                                   bg>{{ buttons[1].text }}</el-button>
                    </router-link>
                    
                </div>
            </div>
        </div>
    </div> 
    </template>
    
    
    <script>
        export default {
            name: "MenuPage",
            data() {
                return {
                    buttons: [
                        { type: 'warning', text: '批改作业' },
                        { type: 'warning', text: '发布作业' },
                    ]
                }
            }
        }
    </script>
    
    <style lang="scss" scoped>
        .teacherHome {
            position: absolute;
            width: 100%;
            height: 100%;
            background-image: url('../../public/images/svgs/login-bg.svg');

            .relative {
                width: 100%;
                height: 100%;
                text-align: center;

                .teacherImg {
                    margin-left: auto;
                    margin-right: auto;
                    margin-top: 100px;
                    line-height: 300px;
                    width: 475px;
                    height: 325px;
                    background-image: url("../../public//images/teacherHome.jpg");
                    background-size: contain;

                    h1 {
                        color: white;
                        font-size: 45px;
                    }
                }

                .bottom {
                    position: relative;
                    top: 30px;
                }
            }
        }
    </style>
    